import { useMemo } from "react";
import { View, StyleSheet } from "react-native";
import { CreateOrUpdateExercise } from "@/app/models/create-or-update-exercise.mode";
import { Exercise } from "@/app/models/exercise.model";
import * as Yup from "yup";
import { Formik, Form } from "formik";
import { FormikInputText } from "../formik/FormikInputText";
import { FormikDropDown } from "../formik/FormikDropdown";
import { Button } from "react-native-paper";
import { EnumExtensions } from "@/app/utils/enum-extensions";
import { BodyPart } from "@/app/shared/enums/body-part.enum";

interface Props {
  exercise: Exercise;
  onSave: (exercise: CreateOrUpdateExercise) => void;
}

export function ExerciseForm({ exercise, onSave }: Props) {
  const bodyPartOptions = useMemo(
    () => EnumExtensions.getLabelAndValues(BodyPart),
    []
  );

  const initialValues: CreateOrUpdateExercise = {
    id: exercise.id ?? 0,
    name: exercise.name ?? "",
    description: exercise.description ?? "",
    bodyPart: exercise.bodyPart ?? 0,
  };

  const validationSchema = Yup.object({
    name: Yup.string().required("Required"),
    description: Yup.string().optional(),
    bodyPart: Yup.number().required("Required"),
  });

  return (
    <View>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={onSave}
        enableReinitialize
        validateOnChange
        validateOnMount
      >
        {(formik) => (
          <>
            <Form style={styles.formContainer}>
              <FormikInputText
                name="name"
                label="Name"
                isIndependent
              />
              <FormikInputText
                name="description"
                label="Description"
                isIndependent
              />
              <FormikDropDown
                options={bodyPartOptions}
                name="bodyPart"
                label="Body part"
                isIndependent
              />
              <Button
                onPress={formik.submitForm}
                mode="contained"
                disabled={!formik.dirty || !formik.isValid}
              >
                Save
              </Button>
            </Form>
          </>
        )}
      </Formik>
    </View>
  );
}

const styles = StyleSheet.create({
  formContainer: {
    display: "flex",
    flexDirection: "column",
    gap: 10,
  },
});
