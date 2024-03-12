import AsyncStorage from "@react-native-async-storage/async-storage";
import { User } from "../models/user.model";
import { ThemeSetting } from "../providers/ThemeProvider/theme-setting.type";
import { handleDates } from "./serialize-date-helpers";

export type KeyTypes = {
  theme: ThemeSetting;
  loggedUser: User;
  token: string;
  language: string;
  downloadedFiles: {
    baseUrl: string;
    localUri: string;
  }[];
};

type Subscriber = {
  id: number;
  key: keyof KeyTypes;
  callback: (value: KeyTypes[keyof KeyTypes] | undefined) => void;
};

export namespace SmartStorage {
  const memoizedValues: { [key in keyof KeyTypes]?: KeyTypes[key] } = {};

  let subLastId = 0;
  const subscribers: Subscriber[] = [];

  export function unsubscribe(subscriptionId: number) {
    return () => {
      const index = subscribers.findIndex((x) => x.id === subscriptionId);
      subscribers.splice(index, 1);
    };
  }

  export async function get<T extends keyof KeyTypes>(
    key: T,
    options?: {
      getMemoizedValue?: boolean;
      setMemoizedValue?: boolean;
    }
  ): Promise<KeyTypes[T] | undefined> {
    let result: KeyTypes[T] | undefined = undefined;
    if (options?.getMemoizedValue !== false) {
      result = memoizedValues[key];
    }
    if (result === undefined) {
      const value = await AsyncStorage.getItem(key);
      if (!value) return;
      try {
        result = JSON.parse(value);
        handleDates(result);
      } catch {
        return undefined;
      }
    }
    return result;
  }

  export async function set<T extends keyof KeyTypes>(
    key: T,
    value: KeyTypes[T] | undefined,
    options?: {
      setMemoizedValue?: boolean;
    }
  ) {
    const newValue = memoizedValues[key] !== value;
    if (options?.setMemoizedValue !== false) {
      memoizedValues[key] = value;
    }
    if (value !== undefined) {
      await AsyncStorage.setItem(key, JSON.stringify(value));
    } else {
      await AsyncStorage.removeItem(key);
    }

    if (newValue) {
      subscribers
        .filter((x) => x.key === key)
        .forEach((x) => {
          x.callback(value);
        });
    }
  }

  export function subscribe<T extends keyof KeyTypes>(
    key: T,
    callback: (value: KeyTypes[T] | undefined) => void
  ) {
    ++subLastId;
    subscribers.push({
      key,
      callback: callback as any,
      id: subLastId,
    });

    return {
      unsubscribe: unsubscribe(subLastId),
    };
  }
}
