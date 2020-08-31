CREATE PROCEDURE[dbo].[Reservation_Read]
	@Id uniqueidentifier
AS
BEGIN

	select
		IdReservation = r.Id,
		ReservationDate = r.[Date],
		EventTitle = e.Title,
		LocationName = l.Name,
		LocationPosition = l.Geoposition
	from dbo.Reservation r
	inner join dbo.Event e on e.Id = r.IdEvent
	left join dbo.Location l on l.Id = e.IdLocation
	where r.Id = @Id

END
GO


CREATE PROCEDURE[dbo].[Reservation_List]
AS
BEGIN

	select
		IdReservation = r.Id,
		ReservationDate = r.[Date],
		EventTitle = e.Title,
		LocationName = l.Name,
		LocationPosition = l.Geoposition
	from dbo.Reservation r
	inner join dbo.Event e on e.Id = r.IdEvent
	left join dbo.Location l on l.Id = e.IdLocation

END
GO