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
	SELECT bd.Id, bd.BookedFrom, bd.LeaveAt, bd.PaidAmount, bd.Comments, gt.Name GuestName, gt.Id GuestId, rm.RoomNumber, rm.Id RoomId
    FROM `BookingDetails` bd
    left join `Guests` gt on bd.BookedBy = gt.Id
    inner join `Bookings` bk on bk.BookingId = bd.Id
    left join `Rooms` rm on rm.Id = bk.RoomId
    order by bd.CreatedAt desc;
END$$
DELIMITER ;

DROP procedure IF EXISTS `sp_get_room_bookinginfo`;
DELIMITER $$
CREATE PROCEDURE `sp_get_room_bookinginfo`(in room_id bigint)
BEGIN
	SELECT bkd.BookedFrom, bkd.LeaveAt, bkd.PaidAmount, bkd.Comments, rm.Rent RoomRent
    FROM `Rooms` rm
    LEFT JOIN `Bookings` bk ON bk.RoomId = rm.Id
    left join `BookingDetails` bkd on bkd.Id = bk.BookingId
    left join `Guests` gt on gt.Id = bkd.BookedBy
    where rm.Id = room_id
    order by rm.Rent asc;
END$$
DELIMITER ;

DROP procedure IF EXISTS `sp_update_booking`;
DELIMITER $$
CREATE PROCEDURE `sp_update_booking`(in booking_id bigint, in prev_roomid bigint, in new_roomid bigint,
 in booked_from datetime, in leave_at datetime,in paid_amount decimal, in comments varchar(300))
BEGIN
	update `BookingDetails` bkd
    SET `BookedFrom` = booked_from,
    `LeaveAt` = leave_at,
    `PaidAmount` = paid_amount,
    `Comments` = comments
    where bkd.Id = booking_id;
    
    update `Bookings` bk
    SET `RoomId` = new_roomid,
    `UpdatedAt` = curdate()
    where bk.RoomId = prev_roomid and bk.BookingId = booking_id;
END$$
DELIMITER ;

DROP procedure IF EXISTS `sp_update_booking`;
DELIMITER $$
CREATE PROCEDURE `sp_update_booking`(in booking_id bigint, in prev_roomid bigint, in new_roomid bigint,
 in booked_from datetime, in leave_at datetime,in paid_amount decimal, in comments varchar(300))
BEGIN
	update `BookingDetails` bkd
    SET `BookedFrom` = booked_from,
    `LeaveAt` = leave_at,
    `PaidAmount` = paid_amount,
    `Comments` = comments
    where bkd.Id = booking_id;
    
    update `Bookings` bk
    SET `RoomId` = new_roomid,
    `UpdatedAt` = curdate()
    where bk.RoomId = prev_roomid and bk.BookingId = booking_id;
END$$
DELIMITER ;

