import { Component, OnInit } from '@angular/core';
import { Puppy } from 'src/app/_models/puppy';
import { PuppiesService } from 'src/app/_service/puppies.service';

@Component({
  selector: 'app-mypuppies',
  templateUrl: './mypuppies.component.html',
  styleUrls: ['./mypuppies.component.scss']
})
export class MypuppiesComponent implements OnInit {
    puppies: Partial<Puppy[]>;
    predicate = 'followedBy';


  constructor(private puppiesService: PuppiesService) { }

  ngOnInit(): void {
    this.loadFollow();
  }

  loadFollow(){
    this.puppiesService.getFollow(this.predicate).subscribe(response => {
      this.puppies = response;
    //  console.log(this.puppies)
    })
  }
}

