import { ScrollView, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import { SegmentedButtons } from "react-native-paper";
import { useAppThemeSetting } from "./providers/ThemeProvider/CustomThemeProvider";

const SettingsScreen = () => {
  const { themeSetting, setThemeSetting } = useAppThemeSetting();
  return (
    <ScrollView style={styles.container}>
      <SegmentedButtons
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
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 5,
    gap: 5,
  },
});

export default SettingsScreen;
