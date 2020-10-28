import { AppError } from "./app-error";

export class CreatedMessage extends AppError {
    constructor(public originalErr?: any) {
      super(originalErr);
    }
  }