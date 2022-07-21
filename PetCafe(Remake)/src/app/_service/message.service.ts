import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Message } from '../_models/message';
import { getPaginatedResult, getPaginationHeaders } from './paginationHepler';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  baseUrl = environment.apiUrl;

  constructor(private Http:HttpClient) { }

  getMessages(pageNumber, pageSize, container){
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    return getPaginatedResult<Message[]>(this.baseUrl + 'message', params, this.Http);
  }

  getMessageThread(username:string){
    return this.Http.get<Message[]>(this.baseUrl+'Message/thread/' + username);
  }

  sendMessage(username:string, content: string){
    return this.Http.post<Message>(this.baseUrl + 'message', {recipientName : username, content})
  }

  deleteMessage(id:number){
    return this.Http.delete(this.baseUrl + 'message/' +id);
  }
}

