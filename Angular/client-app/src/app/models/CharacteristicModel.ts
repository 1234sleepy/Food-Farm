export interface CharacteristicModel {
    key: string;
    value: string;
    children: CharacteristicModel[];
    isGroup: boolean
    _disabled: boolean;
    _hoverTop: boolean;
    _hoverBottom: boolean
}