import { Exercise } from "../models/exercise.model";
import { Text } from "react-native-paper";
import { List } from "react-native-paper";
import { StyleSheet, View } from "react-native";
import { BodyPart } from "../shared/enums/body-part.enum";
import { useAppTheme } from "../providers/ThemeProvider/CustomThemeProvider";

export function ExerciseListElement({ exercise }: { exercise: Exercise }) {
  const theme = useAppTheme();

  return (
    <View style={[styles.accordionContainer]}>
      <List.Accordion
        title={exercise.name}
        style={[
          styles.accordion,
          { backgroundColor: theme.colors.elevation.level1 },
        ]}
      >
        <View
          style={[
            styles.contentContainer,
            { backgroundColor: theme.colors.elevation.level1 },
          ]}
        >
          <Text variant="bodyMedium">{BodyPart[exercise.bodyPart]}</Text>
          {!!exercise.description && (
            <Text variant="bodyMedium">{exercise.description}</Text>
          )}
        </View>
      </List.Accordion>
    </View>
  );
}

const styles = StyleSheet.create({
  accordion: {
    padding: 5,
    paddingHorizontal: 15,
  },
  accordionContainer: {
    borderRadius: 20,
    overflow: "hidden",
    marginHorizontal: 9,
    marginVertical: 8,
  },
  contentContainer: {
    paddingHorizontal: 10,
    paddingBottom: 5,
    margin: 0,
  },
});
