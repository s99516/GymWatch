import { TrainingState } from "../shared/enums/training-state.enum";
import { TrainingInstanceExercise } from "./training-instance-exercise";
import { User } from "./user.model";

export interface TrainingInstance {
  id: number;
  name: string;
  dateCreated: Date;
  bodyWeight: number;
  trainingState: TrainingState;

  userId: number;

  user?: User;
  trainingInstanceExercises?: TrainingInstanceExercise[];
}
