export interface Message {
  id: number;
  senderId: number;
  senderUsername: string;
  senderPhotoUrl: string;
  reipientId: number;
  reipientUsername: string;
  reipientPhotoUrl: string;
  content: string;
  dateRead?: Date;
  messageSent: Date;
}
