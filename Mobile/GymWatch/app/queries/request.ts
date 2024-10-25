import axios, { AxiosError, AxiosResponse, HttpStatusCode } from "axios";
import { handleDates } from "../utils/serialize-date-helpers";
import { SmartStorage } from "../utils/SmartStorage";
import { API_URL } from "../constants/Urls";

const request = axios.create({
  baseURL: API_URL,
  timeout: 30000,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

request.interceptors.response.use(
  (response: AxiosResponse) => {
    handleDates(response);

    const newToken = response.headers["x-refresh-token"];
    if (newToken && typeof newToken === "string") {
      SmartStorage.get("token").then((result) => {
        if (result) {
          SmartStorage.set("token", newToken);
        }
      });
    }

    return response;
  },
  (error: AxiosError<any>) => {
    if (!(error instanceof AxiosError)) return Promise.reject(error);

    if (error.response?.status === HttpStatusCode.Unauthorized) {
      SmartStorage.set("token", undefined);
      SmartStorage.set("loggedUser", undefined);
    }

    return Promise.reject(error);
  }
);

export default request;
