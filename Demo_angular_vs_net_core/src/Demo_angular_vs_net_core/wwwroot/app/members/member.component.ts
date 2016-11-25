import { Component, OnInit } from '@angular/core';
import { MemberService } from './member.service';
import { Member } from './member';

@Component({
    moduleId: module.id,
    selector: 'list-members',
    templateUrl: 'member.component.html',
    //styleUrls:['styles.css']
})
export class MembersComponent implements OnInit {
    constructor(
        private memberService: MemberService
    ) { }

    members: Member[];

    ngOnInit() {
        this.getList();
    }

    selectedMember: Member;
    

    getList() {
        this.memberService
            .getMembers()
            .subscribe(members => this.members = members);

    }

    //add(name: string): void {
    //    name = name.trim();
    //    if (!name) { return; }
    //    this.memberService.addMember(name)
    //        .then(mem => {
    //            this.heroes.push(hero);
    //            this.selectedHero = null;
    //        });
    //}

    onSelect(value: Member)
    {
        this.selectedMember = value;
    }
    
}