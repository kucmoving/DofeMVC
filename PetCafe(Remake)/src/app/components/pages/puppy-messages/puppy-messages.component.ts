import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Message } from 'src/app/_models/message';
import { Puppy } from 'src/app/_models/puppy';
import { MessageService } from 'src/app/_service/message.service';

@Component({
  selector: 'app-puppy-messages',
  templateUrl: './puppy-messages.component.html',
  styleUrls: ['./puppy-messages.component.scss']
})

export class MemberMessagesComponent implements OnInit {
    @ViewChild('messageForm') messageForm: NgForm;
    @Input() puppy:Puppy;
    messages: Message[];
    messageContent:string;

    constructor(private messageService: MessageService) { }

    ngOnInit(): void {
      this.loadMessages();
   //   console.log(this.puppy)
    }

    loadMessages(){
      this.messageService.getMessageThread(this.puppy.userName).subscribe(messages=>{
        this.messages = messages;
    //    console.log(this.messages)

      })
    }
    sendMessage(){
        this.messageService.sendMessage(this.puppy.userName, this.messageContent)
        .subscribe(message=>{
          this.messages.push(message);
          this.messageForm.reset();
        })
      }


}
