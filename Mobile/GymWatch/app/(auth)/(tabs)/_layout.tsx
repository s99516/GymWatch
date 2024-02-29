import React from "react";
import FontAwesome from "@expo/vector-icons/FontAwesome";
import { Link, Tabs } from "expo-router";
import { Pressable } from "react-native";
import Colors from "@/constants/Colors";
import { useColorScheme } from "@/components/useColorScheme";
import { useClientOnlyValue } from "@/components/useClientOnlyValue";
import { Icon } from "react-native-paper";
import SettingsButton from "@/app/components/settings-button";

export default function TabLayout() {
  const colorScheme = useColorScheme();

  return (
    <Tabs
      initialRouteName="training"
      screenOptions={{
        tabBarActiveTintColor: Colors[colorScheme ?? "light"].tint,
        headerShown: useClientOnlyValue(false, true),
      }}
    >
      <Tabs.Screen
        name="training"
        options={{
          title: "Training",
          tabBarIcon: ({ color }) => (
            <Icon
              source="arm-flex"
              color={color}
              size={30}
            />
          ),
          headerRight: () => <SettingsButton />,
        }}
      />
      <Tabs.Screen
        name="exercises"
        options={{
          title: "Exercises",
          tabBarIcon: ({ color }) => (
            <Icon
              source="weight-lifter"
              color={color}
              size={30}
            />
          ),
          headerRight: () => <SettingsButton />,
        }}
      />
      <Tabs.Screen
        name="reports"
        options={{
          title: "Reports",
          tabBarIcon: ({ color }) => (
            <Icon
              source="chart-line"
              color={color}
              size={30}
            />
          ),
          headerRight: () => <SettingsButton />,
        }}
      />
    </Tabs>
  );
}
