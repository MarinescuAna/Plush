export class AppError {
    originalError: string;
    debugger
    constructor(public originalErr?: any) {
      this.originalError = originalErr != null ? originalErr : null;
    }
  }