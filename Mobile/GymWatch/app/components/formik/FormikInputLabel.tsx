import { ReactNode, useMemo } from "react";
import { HelperText, Text } from "react-native-paper";
import * as Yup from "yup";
import { useAppTheme } from "@/app/providers/ThemeProvider/CustomThemeProvider";

interface FormInputLabelProps {
  nameFor?: string;
  validationSchema?: Yup.ObjectSchema<any, Yup.AnyObject, any, "">;
  children?: ReactNode;
  forceIsRequired?: boolean;
}

export function FormInputLabel({
  nameFor,
  validationSchema,
  children,
  forceIsRequired,
}: FormInputLabelProps) {
  const theme = useAppTheme();

  const isRequired = useMemo(() => {
    if (!validationSchema || !nameFor) return false;
    if (forceIsRequired !== undefined) return forceIsRequired;

    try {
      validationSchema.validateSyncAt(nameFor, {});
      return false;
    } catch (validationError) {
      return true;
    }
  }, [validationSchema, nameFor, forceIsRequired]);

  return (
    <HelperText type="info">
      {children}
      {isRequired && <Text style={{ color: theme.colors.error }}>{" *"}</Text>}
    </HelperText>
  );
}
