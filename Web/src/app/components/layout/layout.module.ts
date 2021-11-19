import { NgModule } from '@angular/core';
import { RouterModule} from "@angular/router";
import { BrowserModule} from "@angular/platform-browser";
import { LayoutComponent } from './layout.component';
import { HeaderModule } from './header/header.module';
import { NavModule } from './nav/nav.module';
import { FooterModule } from './footer/footer.module';



@NgModule({
  declarations: [LayoutComponent],
  imports: [BrowserModule, RouterModule, HeaderModule, NavModule, FooterModule],
    exports: [LayoutComponent]
})
export class LayoutModule { }
