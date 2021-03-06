import { Component, OnInit } from '@angular/core';
import { Message } from 'src/app/_models/message';
import { Pagination } from 'src/app/_models/pagination';
import { MessageService } from 'src/app/_service/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
    messages: Message[];
    pagination: Pagination;
    container = "Unread";
    pageNumber = 1;
    pageSize = 5;
    loading = false;

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.loadMessages();
  //  console.log(this.messages);
  }

  loadMessages(){
    this.loading = true;
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container)
    .subscribe(response =>{
      this.messages =response.result;
   //   console.log(response);
   //   console.log(response.result);

      this.pagination = response.pagination;
      this.loading = false;
    })
  }

  pageChanged(event:any){
    this.pageNumber = event.page;
    this.loadMessages();}

  deleteMessage(id: number) {
    this.messageService.deleteMessage(id).subscribe(() => {
          this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
        })
    }
}




