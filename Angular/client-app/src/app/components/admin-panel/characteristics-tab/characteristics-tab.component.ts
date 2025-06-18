import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CharacteristicModel } from '../../../models/CharacteristicModel';

@Component({
  selector: 'app-characteristics-tab',
  imports: [CommonModule, FormsModule],
  templateUrl: './characteristics-tab.component.html',
  styleUrl: './characteristics-tab.component.css'
})
export class CharacteristicsTabComponent {



  characteristic: CharacteristicModel[] = [];

  _hoverTop: boolean = false;



  model = {} as CharacteristicModel;

  gr:CharacteristicModel[] =[];

  isAction: boolean = false;


  addCharacteristic() {
    this.model = { key: '', value: '', isGroup: false, _disabled: false, children: [],_hoverTop:false, _hoverBottom:false};
    this.characteristic.push(this.model);
    this.isAction = true;
  }

    addCharacteristicBetween(group: CharacteristicModel) {
    this.model = {key: '', value: '', isGroup: false, _disabled: false, children: [],_hoverTop:false, _hoverBottom:false};
    this.gr = this.characteristic.slice(0, this.characteristic.indexOf(group) + 1);
    this.gr.push(this.model);
    this.gr.push(...this.characteristic.slice(this.characteristic.indexOf(group) + 1));
    this.characteristic = this.gr;
    this.isAction = true;
    this.gr = [];
  }


  confirmCharacteristic() {
    this.model = {} as CharacteristicModel;
    this.isAction = false;
    console.log(this.characteristic)
  }

  removeCharacteristic(key: string) {
    this.characteristic = this.characteristic.filter(c => c.key == key && !c.isGroup);
  }


  addGroup() {
    this.characteristic.push({key: '', value: '', isGroup: true, _disabled: false, children: [],_hoverTop:false, _hoverBottom:false});
    this.isAction = true;
  }

  addGroupBetween(group: CharacteristicModel) {
    this.model = {key: '', value: '', isGroup: true, _disabled: false, children: [],_hoverTop:false, _hoverBottom:false};
    this.gr = this.characteristic.slice(0, this.characteristic.indexOf(group) + 1);
    this.gr.push(this.model);
    this.gr.push(...this.characteristic.slice(this.characteristic.indexOf(group) + 1));
    this.characteristic = this.gr;
    this.isAction = true;
    this.gr = [];
  }

  confirmGroup() {
    this.isAction = false;
  }

  removeGroup(group: CharacteristicModel) {
    this.characteristic = this.characteristic.filter(g => g.key !== group.key && g.isGroup);
  }

  addCharacteristicToGroup(group: CharacteristicModel){
    this.model = {key: '', value: '', isGroup: false, _disabled: false, children: [],_hoverTop:false, _hoverBottom:false};
    this.characteristic.find(g => g.key === group.key)?.children.push(this.model);
    this.isAction = true
  }

  confirmCharacteristicGroup(group: CharacteristicModel){
    this.model = {} as CharacteristicModel;
    this.isAction = false;
  }
}