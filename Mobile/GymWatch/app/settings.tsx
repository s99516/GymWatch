import { ScrollView, StyleSheet } from "react-native";
import { SegmentedButtons } from "react-native-paper";
import { useAppThemeSetting } from "./providers/ThemeProvider/CustomThemeProvider";
import { Button } from "react-native-paper";

const SettingsScreen = () => {
  const { themeSetting, setThemeSetting } = useAppThemeSetting();
  return (
    <ScrollView style={styles.container}>
      <SegmentedButtons
        style={styles.segmentedButtons}
        value={themeSetting}
        onValueChange={(e) => {
          if (e === "auto" || e === "dark" || e === "light") setThemeSetting(e);
          else setThemeSetting("auto");
        }}
        buttons={[
          {
            icon: "white-balance-sunny",
            value: "light",
            label: "Light",
          },
          {
            icon: "weather-night",
            value: "dark",
            label: "Dark",
          },
          {
            value: "auto",
            label: "Auto",
          },
        ]}
      />
      <Button
        mode="contained"
        onPress={() =>
          console.log("Navigating to settings page to be implemented")
        }
      >
        Edit account
      </Button>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 5,
  },
  segmentedButtons: {
    marginBottom: 5,
  },
});

export default SettingsScreen;
