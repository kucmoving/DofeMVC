import { User } from "./user";

export class UserParams{
    role="";
    minExp=0;
    maxExp=20;
    pageNumber =1;
    pageSize=5;
    orderBy = "lastTime";

    constructor(user: User){
      this.role = user.role === 'Traveller' ? 'Traveller':'Guide';
    }
  }
