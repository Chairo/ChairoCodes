restore filelistonly from disk = 'E:\DBBackup\CSHCampus_2008-12-16.bak'
go

backup database CSHCampus to disk = 'E:\DBBackup\CSHCampus_200812161720_NoUse.bak'
go

restore database CSHCampus from disk = 'E:\DBBackup\CSHCampus_2008-12-16.bak'
with move 'CSHStd_Data' to 'd:\data\CSHStd_Data.mdf' ,
     move 'CSHStd_Log' to 'd:\log\CSHStd_Log.ldf' ,replace