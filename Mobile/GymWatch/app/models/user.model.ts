import { TrainingInstance } from "./training-instance.model";
import { Exercise } from "./exercise.model";

export interface User {
  id: number;
  email: string;
  dateCreated: Date;

  trainingInstances?: TrainingInstance[];
  exercises?: Exercise[];
}
