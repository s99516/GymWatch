/**
 * Learn more about Light and Dark modes:
 * https://docs.expo.io/guides/color-schemes/
 */

import { KeyboardAvoidingView, Platform, useColorScheme } from "react-native";

import Colors from "../../constants/Colors";

import {
  DarkTheme,
  DefaultTheme,
  ThemeProvider,
} from "@react-navigation/native";

import {
  PaperProvider,
  adaptNavigationTheme,
  useTheme,
  MD3DarkTheme,
  MD3LightTheme,
} from "react-native-paper";
import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useState,
} from "react";
import { StyleSheet } from "react-native";
import { StatusBar } from "expo-status-bar";
import * as SystemUI from "expo-system-ui";
import { SmartStorage } from "@/app/utils/SmartStorage";
import { useSplashScreenController } from "../SplashScreenProvider/SplashScreenProvider";

const customLightTheme = {
  ...MD3LightTheme,
  colors: {
    ...Colors.light,
    glassy: Platform.OS === "android" ? "#FFF6" : "#FFF8",
  },
};

const customDarkTheme = {
  ...MD3DarkTheme,
  colors: {
    ...Colors.dark,
    glassy: Platform.OS === "android" ? "#0006" : "#0008",
  },
};

export const useAppTheme = () =>
  useTheme<typeof customLightTheme & typeof customDarkTheme>();

const adaptedThemes = adaptNavigationTheme({
  reactNavigationLight: DefaultTheme,
  reactNavigationDark: DarkTheme,
  materialLight: customLightTheme,
  materialDark: customDarkTheme,
});

export type ThemeSettings = "auto" | "dark" | "light";
const ThemeSettingContext = createContext<{
  themeSetting: ThemeSettings;
  setThemeSetting: (setting: ThemeSettings) => void;
  currentTheme: Exclude<ThemeSettings, "auto">;
}>({
  themeSetting: "auto",
  setThemeSetting: () => {},
  currentTheme: "dark",
});

export const useAppThemeSetting = () => useContext(ThemeSettingContext);

export function CustomThemeProvider({
  children,
}: {
  children: React.ReactNode;
}) {
  const [themeSetting, setThemeSetting] = useState<ThemeSettings>("auto");
  const systemColorScheme = useColorScheme() ?? "dark";
  const currentTheme =
    themeSetting !== "auto" ? themeSetting : systemColorScheme;

  const splashScreenController = useSplashScreenController();

  useEffect(() => {
    SmartStorage.get("theme").then((x) => {
      setThemeSetting(x ?? "auto");
      splashScreenController.release("Theme");
    });
  }, [splashScreenController]);

  const onThemeSettingChange = useCallback((setting: ThemeSettings) => {
    SmartStorage.set("theme", setting);
    setThemeSetting(setting);
  }, []);

  useEffect(() => {
    SystemUI.setBackgroundColorAsync(
      currentTheme === "light" ? "white" : "black"
    );
  }, [currentTheme]);

  return (
    <ThemeSettingContext.Provider
      value={{
        themeSetting,
        setThemeSetting: onThemeSettingChange,
        currentTheme,
      }}
    >
      <KeyboardAvoidingView
        style={styles.container}
        behavior={Platform.OS === "ios" ? "padding" : "height"}
      >
        <PaperProvider
          theme={currentTheme === "light" ? customLightTheme : customDarkTheme}
        >
          <ThemeProvider
            value={
              currentTheme === "light"
                ? adaptedThemes.LightTheme
                : adaptedThemes.DarkTheme
            }
          >
            <>
              <StatusBar style={currentTheme === "light" ? "dark" : "light"} />
              {children}
            </>
          </ThemeProvider>
        </PaperProvider>
      </KeyboardAvoidingView>
    </ThemeSettingContext.Provider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});
