import { useQuery } from "react-query";
import { exerciseService } from "./services/exercise.service";
import { Exercise } from "../models/exercise.model";

export function useDefaultExercisesQuery() {
  return useQuery<Exercise[]>(["exercises"], () =>
    exerciseService.getDefaultExercises()
  );
}
