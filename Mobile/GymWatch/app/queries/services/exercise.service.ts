import { Exercise } from "@/app/models/exercise.model";
import { BaseService } from "./base-service";
import { API_URL } from "@/app/constants/Urls";

class ExerciseService extends BaseService {
  async getDefaultExercises(): Promise<Exercise[]> {
    const url = `${API_URL}exercises`;
    console.log(url);
    return this.http.get<Exercise[]>(url).then((x) => x.data);
  }
}

export const exerciseService = new ExerciseService();
