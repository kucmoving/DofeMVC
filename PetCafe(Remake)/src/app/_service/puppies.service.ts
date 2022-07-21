import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { Puppy } from '../_models/puppy';
import { UserParams } from '../_models/userParams';
import { getPaginatedResult, getPaginationHeaders } from './paginationHepler';

@Injectable({
  providedIn: 'root'
})
export class PuppiesService {
  baseUrl = environment.apiUrl;
  puppies: Puppy[] = [];
  PaginatedResult: PaginatedResult<Puppy[]> = new PaginatedResult<Puppy[]>();


  constructor(private http: HttpClient) { }

  //put pageNumber,pageSize as parameters
  getPuppies(userParams: UserParams){
    let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);
    if (userParams != null){
    params = params.append('minExp', userParams.minExp.toString());
    params = params.append('maxExp', userParams.maxExp.toString());
    params = params.append('role', userParams.role);
    params = params.append('orderBy', userParams.orderBy);
    }
    return getPaginatedResult<Puppy[]>(this.baseUrl + 'user', params, this.http);
  }




  getPuppy(username: string){
    return this.http.get<any>(this.baseUrl + 'User/' + username);
  }

  updatePuppy(puppy: Puppy){
    return this.http.put(this.baseUrl + 'user', puppy);
  }

  setMainPhoto(photoId: number){
    return this.http.put(this.baseUrl + 'user/set-main-photo/' + photoId, {});
  }

  deletePhoto(photoId: number){
    return this.http.delete(this.baseUrl + 'user/delete-photo/' + photoId);
  }

  addFollow(username: string){
    return this.http.post(this.baseUrl + 'follow/' + username, {})
  }

  getFollow(predicate: string){          //string query = "?="
    return this.http.get<Partial<Puppy[]>>(this.baseUrl + 'Follow?predicate=' + predicate);
  }
}
//https://localhost:7141/api/Follow?predicate=following




