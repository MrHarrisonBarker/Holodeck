import { Component } from '@angular/core';
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-home',
  templateUrl: './' + environment.namingPrefix + 'home.component.html',
})
export class HomeComponent {
  title = "Hello, world! welcome to holodeck"
}
