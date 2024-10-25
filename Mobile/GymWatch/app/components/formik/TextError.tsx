import { HelperText } from "react-native-paper";

export function TextError(props: any) {
  return <HelperText type="error">{props.children}</HelperText>;
}
