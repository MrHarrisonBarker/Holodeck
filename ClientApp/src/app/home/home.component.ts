import { Component } from '@angular/core';
import {namingPrefix} from "../../main";

@Component({
  selector: 'app-home',
  templateUrl: './' + namingPrefix + 'home.component.html',
})
export class HomeComponent {
  title = "Hello, world! welcome to holodeck"
}
