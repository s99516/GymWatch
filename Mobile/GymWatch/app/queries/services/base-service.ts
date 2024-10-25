import AxiosInstance from "../request";

export class BaseService {
  protected readonly http = AxiosInstance;
  constructor() {}
}
