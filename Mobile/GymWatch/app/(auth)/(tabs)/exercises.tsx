import { View, StyleSheet } from "react-native";
import { useDefaultExercisesQuery } from "@/app/queries/exercise.query";
import { TextInput } from "react-native-paper";
import { useState, useCallback } from "react";
import { FlatList } from "react-native";
import { ExerciseListElement } from "@/app/components/ExerciseListElement";
import { FAB } from "react-native-paper";
import { useRouter } from "expo-router";

const ExercisesScreen = () => {
  const [filter, setFilter] = useState("");
  const router = useRouter();
  const exercisesQuery = useDefaultExercisesQuery();

  const handleCreateNewExercise = useCallback(() => {
    router.push({ pathname: "/exercise/details" });
  }, []);

  return (
    <View style={styles.container}>
      <TextInput
        label="Szukaj"
        value={filter}
        onChangeText={(e) => setFilter(e)}
      />
      <FlatList
        data={exercisesQuery.data}
        renderItem={(item) => <ExerciseListElement exercise={item.item} />}
      />
      <FAB
        icon="plus"
        style={styles.fabStyle}
        onPress={handleCreateNewExercise}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 5,
    gap: 5,
  },
  fabStyle: {
    bottom: 20,
    right: 20,
    position: "absolute",
  },
});

export default ExercisesScreen;
