import { View } from "react-native";
import { Text } from "react-native-paper";
import { StyleSheet } from "react-native";
import { ExerciseForm } from "@/app/components/forms/ExerciseForm";
import { Exercise } from "@/app/models/exercise.model";

const ExerciseDetailsScreen = () => {
  return (
    <View style={styles.container}>
      <ExerciseForm
        exercise={{ name: "" } as Exercise}
        onSave={(exercise) => console.log(exercise)}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 10,
  },
});

export default ExerciseDetailsScreen;
