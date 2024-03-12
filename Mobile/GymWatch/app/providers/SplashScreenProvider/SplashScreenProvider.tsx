import { SplashScreen } from "expo-router";
import {
  createContext,
  useContext,
  useEffect,
  useMemo,
  useState,
  useRef,
  useCallback,
} from "react";

export const splashScreenKeys = [
  "Translations",
  "Authorization",
  "Theme",
] as const;

export type SplashScreenContentType = {
  hidden: boolean;
  release: (key: (typeof splashScreenKeys)[number]) => void;
};

export const SplashScreenContext = createContext<SplashScreenContentType>({
  hidden: false,
  release: () => {},
});

export const useSplashScreenController = () => useContext(SplashScreenContext);

export function useReleaseSplashScreen(
  key: (typeof splashScreenKeys)[number],
  when: boolean | number = true
) {
  const controller = useSplashScreenController();
  useEffect(() => {
    if (when === true) {
      controller.release(key);
    }
    if (typeof when === "number") {
      setTimeout(() => controller.release(key), when);
    }
  }, [when]);
}

export function SplashScreeControllerProvider({
  children,
}: {
  children: React.ReactNode;
}) {
  const [hidden, setHidden] = useState(false);
  const initialValues = useMemo(() => {
    return Object.fromEntries(splashScreenKeys.map((x) => [x, false])) as {
      [key in (typeof splashScreenKeys)[number]]: boolean;
    };
  }, [splashScreenKeys]);
  const keysRef = useRef(initialValues);

  const release = useCallback(
    (key: (typeof splashScreenKeys)[number]) => {
      if (hidden) return;
      const currentValue = keysRef.current[key];
      if (currentValue) return;
      keysRef.current[key] = true;
      if (Object.values(keysRef.current).every((x) => x)) {
        setHidden(true);
      }
    },
    [hidden]
  );

  useEffect(() => {
    if (hidden) {
      SplashScreen.hideAsync();
    }
  }, [hidden]);

  return (
    <SplashScreenContext.Provider
      value={{
        hidden,
        release,
      }}
    >
      {children}
    </SplashScreenContext.Provider>
  );
}
