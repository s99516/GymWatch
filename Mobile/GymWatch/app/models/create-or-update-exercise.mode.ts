import { BodyPart } from "../shared/enums/body-part.enum";

export interface CreateOrUpdateExercise {
  id: number;
  name: string;
  description: string;
  bodyPart: BodyPart;
  userId?: number;
}
