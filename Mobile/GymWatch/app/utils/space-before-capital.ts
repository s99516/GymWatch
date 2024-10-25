export class SpaceBeforeCapital {
  static transform(value: string): string {
    if (value) {
      const result = value.replace(/(A-Z0-9)/g, "$1").trim();
      return result.charAt(0) + result.substring(1).toLowerCase();
    }
    return "";
  }
}
