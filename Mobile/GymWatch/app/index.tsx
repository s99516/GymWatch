import { useRouter } from "expo-router";
import {
  View,
  StyleSheet,
  ActivityIndicator as RNActivityIndicator,
} from "react-native";
import { useEffect } from "react";

const IndexScreen = () => {
  const router = useRouter();

  useEffect(() => {
    setTimeout(() => {
      router.replace("/training");
    }, 100);
  }, [router]);

  return (
    <View style={styles.container}>
      <RNActivityIndicator
        size={100}
        color="#4CAF50"
      ></RNActivityIndicator>
    </View>
  );
};

export default IndexScreen;

const styles = StyleSheet.create({
  container: {
    width: "100%",
    height: "100%",
    alignItems: "center",
    justifyContent: "center",
  },
});
