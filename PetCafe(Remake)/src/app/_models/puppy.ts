import { Photo } from "./photo"

export interface Puppy {
    id: number;
    userName: string;
    photoUrl: string;
    created: Date;
    lastTime: Date;
    nickName: string;
    story: string;
    role: string;
    preferStyle: string;
    gender: string;
    region: string;
    photos: Photo[];
    experience: number;
}

