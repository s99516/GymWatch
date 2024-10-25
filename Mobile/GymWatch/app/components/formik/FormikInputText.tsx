import { memo, useMemo } from "react";
import { View } from "react-native";
import { FormInputLabel } from "./FormikInputLabel";
import {
  ErrorMessage,
  FastField,
  Field,
  FieldInputProps,
  FieldMetaProps,
  FormikContextType,
} from "formik";
import { TextInput } from "react-native-paper";
import { TextError } from "./TextError";
import * as Yup from "yup";

interface FormikInputTextProps {
  label: string;
  name: string;
  password?: boolean;
  isIndependent?: boolean;
  validationSchema?: Yup.ObjectSchema<any, Yup.AnyObject, any, "">;
  isRequired?: boolean;
}

export const FormikInputText = memo(
  ({
    label,
    name,
    password = false,
    isIndependent = false,
    validationSchema,
    isRequired = undefined,
    ...rest
  }: FormikInputTextProps) => {
    const Component = useMemo(() => {
      return isIndependent ? FastField : Field;
    }, [isIndependent]);

    return (
      <View>
        <FormInputLabel
          nameFor={name}
          validationSchema={validationSchema}
          forceIsRequired={isRequired}
        >
          {label}
        </FormInputLabel>
        <Component name={name}>
          {({
            form,
            field,
            meta,
          }: {
            form: FormikContextType<any>;
            field: FieldInputProps<string>;
            meta: FieldMetaProps<string>;
          }) => (
            <TextInput
              secureTextEntry={password}
              id={name}
              placeholder={label}
              value={field.value}
              mode="outlined"
              theme={{
                colors: { primary: "#388E3C" },
              }}
              onBlur={(e) => form.setFieldTouched(name, true)}
              onChangeText={(e) => {
                form.setFieldValue(name, e);
              }}
              {...rest}
            />
          )}
        </Component>
        <ErrorMessage
          component={TextError}
          name={name}
        />
      </View>
    );
  }
);
