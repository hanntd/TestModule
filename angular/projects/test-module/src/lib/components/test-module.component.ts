import { Component, OnInit } from '@angular/core';
import { TestModuleService } from '../services/test-module.service';

@Component({
  selector: 'lib-test-module',
  template: ` <p>test-module works!</p> `,
  styles: [],
})
export class TestModuleComponent implements OnInit {
  constructor(private service: TestModuleService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
