import { BodyPart } from "../shared/enums/body-part.enum";

export interface Exercise {
  id: number;
  name: string;
  description: string;
  dateCreated: Date;
  isCustom: boolean;
  bodyPart: BodyPart;
  userId?: number;
}
