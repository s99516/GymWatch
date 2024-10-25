import { memo, useMemo, useRef } from "react";
import { FormInputLabel } from "./FormikInputLabel";
import {
  ErrorMessage,
  FastField,
  Field,
  FieldInputProps,
  FieldMetaProps,
  FormikContextType,
} from "formik";
import { Dropdown, IDropdownRef } from "react-native-element-dropdown";
import { TextError } from "./TextError";
import { IconButton, Text, TextInput } from "react-native-paper";
import { SelectItem } from "@/app/utils/select-item";
import { useAppTheme } from "@/app/providers/ThemeProvider/CustomThemeProvider";
import { View } from "react-native";
import * as Yup from "yup";

export interface FormikDropDownPros {
  label: string;
  name: string;
  options?: SelectItem<number>[];
  isIndependent?: boolean;
  disabled?: boolean;
  validationSchema?: Yup.ObjectSchema<any, Yup.AnyObject, any, "">;
  isRequired?: boolean;
}

export const FormikDropDown = memo(
  ({
    label,
    name,
    options = [],
    isIndependent = false,
    disabled = false,
    validationSchema,
    isRequired = undefined,
    ...rest
  }: FormikDropDownPros) => {
    const Component = useMemo(() => {
      return isIndependent ? FastField : Field;
    }, [isIndependent]);

    const theme = useAppTheme();
    const dropdownRef = useRef<IDropdownRef>(null);

    return (
      <>
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
            field: FieldInputProps<any>;
            meta: FieldMetaProps<string>;
          }) => {
            return (
              <Dropdown
                ref={dropdownRef}
                placeholder={label}
                search
                mode="modal"
                style={{
                  borderRadius: theme.roundness,
                  borderColor: theme.colors.outline,
                  borderWidth: 1,
                  paddingHorizontal: 15,
                  paddingVertical: 7,
                  height: 60,
                }}
                containerStyle={{
                  backgroundColor: theme.colors.background,
                  borderWidth: 1,
                  borderRadius: theme.roundness * 5,
                  borderColor: theme.colors.inverseSurface,
                  overflow: "scroll",
                  maxHeight: "85%",
                }}
                itemTextStyle={{ color: theme.colors.onBackground }}
                selectedTextStyle={{ color: theme.colors.onBackground }}
                itemContainerStyle={{
                  backgroundColor: theme.colors.background,
                  borderTopWidth: 1,
                  borderTopColor: theme.colors.onSurface,
                }}
                activeColor={theme.colors.primaryContainer}
                placeholderStyle={{
                  color: field.value
                    ? theme.colors.onBackground
                    : theme.colors.outline,
                }}
                labelField="label"
                valueField="value"
                renderInputSearch={(search) => {
                  return (
                    <>
                      <View
                        style={{
                          flexDirection: "row",
                        }}
                      >
                        <Text
                          style={[
                            theme.fonts.titleLarge,
                            {
                              padding: 15,
                              flexGrow: 1,
                              flexShrink: 1,
                            },
                          ]}
                        >
                          {label}
                        </Text>
                        <IconButton
                          icon="close"
                          style={{
                            alignSelf: "center",
                          }}
                          onPress={() => dropdownRef.current?.close()}
                        />
                      </View>
                      <TextInput
                        onChangeText={search}
                        label={"Search"}
                        left={<TextInput.Icon icon="magnify" />}
                      />
                    </>
                  );
                }}
                value={field.value}
                onChange={(v) => {
                  form.setFieldValue(name, v.value);
                }}
                data={options}
              />
            );
          }}
        </Component>
        <ErrorMessage
          component={TextError}
          name={name}
        />
      </>
    );
  }
);
