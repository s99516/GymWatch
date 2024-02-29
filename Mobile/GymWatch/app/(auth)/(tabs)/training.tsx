import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";

const TrainingScreen = () => {
  return (
    <View style={styles.container}>
      <Text>Training screen</Text>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 5,
    gap: 5,
  },
});

export default TrainingScreen;
