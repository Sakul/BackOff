﻿Feature: VerifyOTP
	In order to ตรวจสอบความถูกต้องการยืนยันรหัสลับ และป้องกันการทำ Brute force
	As a ระบบ
	I want ป้องกันไม่ให้ระบบถูกโกงจากทุกกรณี

Background:
	Given ระบบทำการกำหนดค่าเริ่มต้นของการทำ OTP
	And ขณะนี้เวลา '1/1/2020 00:00:00'

Scenario: ยืนยัน OTP ถูกต้อง ระบบกำหนดให้การยืนยันผ่าน และทำการรีเซ็ต attempt cout ของเบอร์นี้
	Given ในระบบมีข้อมูลการขอรหัส OTP เป็นดังนี้
		| Phone      | Code   | AttemptCount |
		| 0914185400 | A1B2C3 | 0            |
	When ทำการยืนยัน OTP ของเบอร์ '0914185400' ด้วยรหัส 'A1B2C3'
	Then ระบบกำหนดให้การยืนยันผ่าน โดยเป็นการทำครั้งที่ '1'
	And ระบบทำการรีเซ็ต attempt count ของเบอร์ '0914185400'

Scenario: ยืนยัน OTP ไม่ถูกต้อง ระบบกำหนดให้การยืนยันไม่ผ่าน และไม่ทำการรีเซ็ต attempt cout ของเบอร์นี้
	Given ในระบบมีข้อมูลการขอรหัส OTP เป็นดังนี้
		| Phone      | Code   | AttemptCount |
		| 0914185400 | A1B2C3 | 0            |
	When ทำการยืนยัน OTP ของเบอร์ '0914185400' ด้วยรหัส 'Invalid'
	Then ระบบกำหนดให้การยืนยันไม่ผ่าน โดยเป็นการทำครั้งที่ '1'
	And ระบบไม่รีเซ็ต attempt count

Scenario: เบอร์ที่ยืนยัน OTP ผิดแต่ยังไม่เกิน 7 ครั้งทำการยืนยันรหัสผ่านถูกต้อง ระบบกำหนดให้การยืนยันผ่าน และทำการรีเซ็ต attempt cout ของเบอร์นี้
	Given ในระบบมีข้อมูลการขอรหัส OTP เป็นดังนี้
		| Phone      | Code   | AttemptCount |
		| 0914185401 | A1B2C3 | 1            |
		| 0914185402 | A1B2C3 | 2            |
		| 0914185403 | A1B2C3 | 3            |
		| 0914185404 | A1B2C3 | 4            |
		| 0914185405 | A1B2C3 | 5            |
		| 0914185406 | A1B2C3 | 6            |
	When ทำการยืนยัน OTP ของเบอร์ '<Phone>' ด้วยรหัส '<Code>'
	Then ระบบกำหนดให้การยืนยันผ่าน โดยเป็นการทำครั้งที่ '<ExpectedAttemptCount>'
	And ระบบทำการรีเซ็ต attempt count ของเบอร์ '<Phone>'

	Examples:
		| Phone      | Code   | ExpectedAttemptCount |
		| 0914185401 | A1B2C3 | 2                    |
		| 0914185402 | A1B2C3 | 3                    |
		| 0914185403 | A1B2C3 | 4                    |
		| 0914185404 | A1B2C3 | 5                    |
		| 0914185405 | A1B2C3 | 6                    |
		| 0914185406 | A1B2C3 | 7                    |

Scenario: เบอร์ที่ยืนยัน OTP ผิดเกิน 7 ครั้งทำการยืนยันรหัสผ่าน ระบบกำหนดให้การยืนยันไม่ผ่าน และไม่รีเซ็ต attempt cout
	Given ในระบบมีข้อมูลการขอรหัส OTP เป็นดังนี้
		| Phone      | Code   | AttemptCount |
		| 0914185407 | A1B2C3 | 7            |
	When ทำการยืนยัน OTP ของเบอร์ '<Phone>' ด้วยรหัส '<Code>'
	Then ระบบกำหนดให้การยืนยันไม่ผ่าน โดยเป็นการทำครั้งที่ '<ExpectedAttemptCount>'
	And ระบบไม่รีเซ็ต attempt count

	Examples:
		| Phone      | Code    | ExpectedAttemptCount |
		| 0914185407 | A1B2C3  | 7                    |
		| 0914185407 | Invalid | 7                    |