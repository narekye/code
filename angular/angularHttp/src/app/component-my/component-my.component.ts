import { Input, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-component-my',
  templateUrl: './component-my.component.html',
  styleUrls: ['./component-my.component.css']
})
export class ComponentMyComponent implements OnInit {

  constructor() { }
  @Input() user;
  ngOnInit() {
    // console.log(this.user);
  }

  Self() {
    alert(this.user);
  }
}
