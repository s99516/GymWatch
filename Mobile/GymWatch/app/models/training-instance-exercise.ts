import { TrainingInstance } from "./training-instance.model";
import { Exercise } from "./exercise.model";

export interface TrainingInstanceExercise {
  id: number;
  sequence: number;
  numberOfSeries: number;
  weight: number;

  trainingInstanceId: number;
  exerciseId: number;

  trainingInstance?: TrainingInstance;
  exercise?: Exercise;
}
