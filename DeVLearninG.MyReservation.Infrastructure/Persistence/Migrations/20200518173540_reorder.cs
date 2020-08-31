using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class reorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
select *
into #tempEvent
from [dbo].[Event]

ALTER TABLE [dbo].[RESERVATION] DROP CONSTRAINT [FK_Reservation_Event_IdEvent]
GO

DROP TABLE [dbo].[Event]
GO

CREATE TABLE [dbo].[Event](
	[Id] [uniqueidentifier] NOT NULL,
	[IdLocation] [uniqueidentifier] NOT NULL,
	[IdEventType] [int] NOT NULL,
	[Date] [datetimeoffset](7) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
	[UpdatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Event] ADD  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Event] ADD  DEFAULT ((0)) FOR [IdEventType]
GO

ALTER TABLE [dbo].[Event] ADD  DEFAULT (sysdatetimeoffset()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Event] ADD  DEFAULT (sysdatetimeoffset()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType_IdEventType] FOREIGN KEY([IdEventType])
REFERENCES [dbo].[EventType] ([Id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType_IdEventType]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Location_IdLocation] FOREIGN KEY([IdLocation])
REFERENCES [dbo].[Location] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Location_IdLocation]
GO


insert into [dbo].[Event]
(
	[Id],
	[IdLocation],
	[IdEventType],
	[Date],
	[Title],
	[Description],
	[CreatedDate],
	[UpdatedDate]
)
select
	[Id],
	[IdLocation],
	[IdEventType],
	[Date],
	[Title],
	[Description],
	[CreatedDate],
	[UpdatedDate]
from #tempEvent


ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Event_IdEvent] FOREIGN KEY([IdEvent])
REFERENCES [dbo].[Event] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Event_IdEvent]
GO


drop table #tempEvent
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
