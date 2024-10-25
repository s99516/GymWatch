import { SelectItem } from "./select-item";
import { SpaceBeforeCapital } from "./space-before-capital";

export class EnumExtensions {
  static getLabelAndValues<T extends number>(e: any): SelectItem<number>[] {
    return EnumExtensions.getNames(e).map((x) => ({
      label: SpaceBeforeCapital.transform(x),
      value: e[x] as T,
    }));
  }

  static getNames(e: any): string[] {
    return Object.values(e).filter((x) => typeof x === "string") as string[];
  }

  static getValues<T extends number>(e: any): T[] {
    return EnumExtensions.getObjValues(e).filter(
      (v) => typeof v === "number"
    ) as T[];
  }

  private static getObjValues(e: any): (number | string)[] {
    return Object.keys(e).map((k) => e[k]);
  }
}
