DROP procedure IF EXISTS `sp_get_roominfolist`;
DELIMITER $$
CREATE PROCEDURE `sp_get_roominfolist`()
BEGIN
	SELECT rm.Id, rm.RoomNumber, rm.Capacity, rm.Rent, 
	count(case when (curdate() between bd.BookedFrom and bd.LeaveAt) OR (curdate() < bd.LeaveAt) then bd.BookedFrom end) OnGoingBooking,
	count(case when curdate() > bd.LeaveAt then bd.BookedFrom end) ClosedBooking
	FROM `Rooms` rm
	LEFT JOIN `Bookings` b ON b.`RoomId` = rm.`Id`
	LEFT JOIN `BookingDetails` bd ON bd.Id = b.BookingId
	group by rm.Id, rm.RoomNumber, rm.Capacity, rm.Rent
    order by rm.CreatedAt desc;
END$$
DELIMITER ;

DROP procedure IF EXISTS `sp_get_bookingdetails`;
DELIMITER $$
CREATE PROCEDURE `sp_get_bookingdetails`()
BEGIN
	SELECT bd.Id, bd.BookedFrom, bd.LeaveAt, bd.Comments, gt.Name GuestName, rm.RoomNumber 
    FROM `BookingDetails` bd
    left join `Guests` gt on bd.BookedBy = gt.Id
    inner join `Bookings` bk on bk.BookingId = bd.Id
    left join `Rooms` rm on rm.Id = bk.RoomId
    order by bd.CreatedAt desc;
END$$
DELIMITER ;