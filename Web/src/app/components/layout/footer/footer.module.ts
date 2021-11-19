import { NgModule } from '@angular/core';
import {BrowserModule} from "@angular/platform-browser";
import {RouterModule} from "@angular/router";
import {FooterComponent} from "./footer.component";



@NgModule({
  declarations: [FooterComponent],
  imports: [BrowserModule],
  exports : [FooterComponent],
})
export class FooterModule { }
