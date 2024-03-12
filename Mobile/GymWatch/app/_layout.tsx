import FontAwesome from "@expo/vector-icons/FontAwesome";
import {
  DarkTheme,
  DefaultTheme,
  ThemeProvider,
} from "@react-navigation/native";
import { useFonts } from "expo-font";
import { Stack } from "expo-router";
import * as SplashScreen from "expo-splash-screen";
import { ComponentProps, useEffect, useMemo } from "react";

import { useColorScheme } from "@/components/useColorScheme";
import { CustomThemeProvider } from "./providers/ThemeProvider/CustomThemeProvider";
import { Appbar, Text } from "react-native-paper";

export {
  // Catch any errors thrown by the Layout component.
  ErrorBoundary,
} from "expo-router";

export const unstable_settings = {
  // Ensure that reloading on `/modal` keeps a back button present.
  initialRouteName: "(auth)/(tabs)",
};

// Prevent the splash screen from auto-hiding before asset loading is complete.
SplashScreen.preventAutoHideAsync();

export default function RootLayout() {
  const [loaded, error] = useFonts({
    SpaceMono: require("../assets/fonts/SpaceMono-Regular.ttf"),
    ...FontAwesome.font,
  });

  // Expo Router uses Error Boundaries to catch errors in the navigation tree.
  useEffect(() => {
    if (error) throw error;
  }, [error]);

  useEffect(() => {
    if (loaded) {
      SplashScreen.hideAsync();
    }
  }, [loaded]);

  if (!loaded) {
    return null;
  }

  return (
    <CustomThemeProvider>
      <RootLayoutNav />
    </CustomThemeProvider>
  );
}

function RootLayoutNav() {
  const colorScheme = useColorScheme();

  const screenOptions: ComponentProps<typeof Stack>["screenOptions"] =
    useMemo(() => {
      return {
        header: (props) => {
          return (
            <>
              <Appbar.Header
                mode="center-aligned"
                elevated
              >
                {props.back && (
                  <Appbar.BackAction
                    onPress={() => {
                      props.navigation.canGoBack() && props.navigation.goBack();
                    }}
                  />
                )}
                <Appbar.Content
                  title={
                    <Text>
                      {props.options.headerTitle
                        ? typeof props.options.headerTitle === "function"
                          ? props.options.headerTitle({
                              children: props.options.title ?? "",
                            })
                          : props.options.headerTitle
                        : props.options.title}
                    </Text>
                  }
                />
              </Appbar.Header>
            </>
          );
        },
      };
    }, []);

  return (
    <Stack screenOptions={screenOptions}>
      <Stack.Screen
        name="index"
        options={{
          animation: "none",
          headerShown: false,
        }}
      />
      <Stack.Screen
        name="(auth)/(tabs)"
        options={{ headerShown: false }}
      />
      <Stack.Screen
        name="settings"
        options={{ presentation: "modal", headerTitle: "Settings" }}
      />
    </Stack>
  );
}
