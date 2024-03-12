import { format, parseISO } from "date-fns";

const isoDateFormat =
  /(\d{4}-[01]\d-[0-3]\dT[0-2]\d:[0-5]\d:[0-5]\d\.\d+([+-][0-2]\d:[0-5]\d|Z))|(\d{4}-[01]\d-[0-3]\dT[0-2]\d:[0-5]\d:[0-5]\d([+-][0-2]\d:[0-5]\d|Z))|(\d{4}-[01]\d-[0-3]\dT[0-2]\d:[0-5]\d([+-][0-2]\d:[0-5]\d|Z))/;

function isIsoDateString(value: any): boolean {
  return value && typeof value === "string" && isoDateFormat.test(value);
}

export function handleDates(body: any) {
  if (body === null || body === undefined || typeof body !== "object")
    return body;

  for (const key of Object.keys(body)) {
    const value = body[key];
    if (isIsoDateString(value)) body[key] = parseISO(value);
    else if (typeof value === "object") handleDates(value);
  }
}

export function toDateString(date: Date) {
  return format(new Date(date), "dd/MM/yyyy");
}

export function toDateTimeString(date: Date) {
  return format(new Date(date), "dd/MM/yyyy HH:mm");
}

export function toLocalizedDate(date: Date) {
  return format(new Date(date), "LLL/dd");
}
