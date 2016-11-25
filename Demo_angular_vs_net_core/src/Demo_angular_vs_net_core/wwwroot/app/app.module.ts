import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { MembersComponent } from './members/member.component';
import { MemberService } from './members/member.service';

@NgModule({
    imports:
    [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations:
    [
        AppComponent,
        MembersComponent
    ],
    providers:
    [
        MemberService
    ]
    ,
    bootstrap:
    [
        AppComponent
    ]
})
export class AppModule { }
