import { View } from "react-native";
import { Link } from "expo-router";
import { Appbar } from "react-native-paper";

export default function SettingsButton() {
  return (
    <View>
      <Link
        href="/settings"
        asChild
      >
        <Appbar.Action icon="cog" />
      </Link>
    </View>
  );
}
