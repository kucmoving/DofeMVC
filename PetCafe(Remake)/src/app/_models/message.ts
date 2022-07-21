export interface Message {
    id: number
    senderId: number
    senderName: string
    senderPhotoUrl: any
    recipientId: number
    recipienName: string
    recipientPhotoUrl: any
    content: string
    readTime: Date
    sendTime: Date
  }
