﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestModule.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace TestModule.Migrations
{
    [DbContext(typeof(TestModuleHttpApiHostMigrationsDbContext))]
    [Migration("20240731085535_add testmoduletable")]
    partial class addtestmoduletable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.SqlServer)
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestModule.TestModuleTables.TestModuleTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Notes");

                    b.HasKey("Id");

                    b.ToTable("TestModuleTestModuleTables", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationName")
                        .HasMaxLength(96)
                        .HasColumnType("nvarchar(96)")
                        .HasColumnName("ApplicationName");

                    b.Property<string>("BrowserInfo")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("BrowserInfo");

                    b.Property<string>("ClientId")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("ClientId");

                    b.Property<string>("ClientIpAddress")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("ClientIpAddress");

                    b.Property<string>("ClientName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("ClientName");

                    b.Property<string>("Comments")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Comments");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("CorrelationId")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("CorrelationId");

                    b.Property<string>("Exceptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExecutionDuration")
                        .HasColumnType("int")
                        .HasColumnName("ExecutionDuration");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtraProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("HttpMethod")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("HttpMethod");

                    b.Property<int?>("HttpStatusCode")
                        .HasColumnType("int")
                        .HasColumnName("HttpStatusCode");

                    b.Property<Guid?>("ImpersonatorTenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ImpersonatorTenantId");

                    b.Property<string>("ImpersonatorTenantName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("ImpersonatorTenantName");

                    b.Property<Guid?>("ImpersonatorUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ImpersonatorUserId");

                    b.Property<string>("ImpersonatorUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("ImpersonatorUserName");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.Property<string>("TenantName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("TenantName");

                    b.Property<string>("Url")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Url");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "ExecutionTime");

                    b.HasIndex("TenantId", "UserId", "ExecutionTime");

                    b.ToTable("AbpAuditLogs", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLogAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditLogId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AuditLogId");

                    b.Property<int>("ExecutionDuration")
                        .HasColumnType("int")
                        .HasColumnName("ExecutionDuration");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExecutionTime");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("MethodName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("MethodName");

                    b.Property<string>("Parameters")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("Parameters");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("ServiceName");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("AuditLogId");

                    b.HasIndex("TenantId", "ServiceName", "MethodName", "ExecutionTime");

                    b.ToTable("AbpAuditLogActions", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditLogId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AuditLogId");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ChangeTime");

                    b.Property<byte>("ChangeType")
                        .HasColumnType("tinyint")
                        .HasColumnName("ChangeType");

                    b.Property<string>("EntityId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("EntityId");

                    b.Property<Guid?>("EntityTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntityTypeFullName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("EntityTypeFullName");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("AuditLogId");

                    b.HasIndex("TenantId", "EntityTypeFullName", "EntityId");

                    b.ToTable("AbpEntityChanges", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityPropertyChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntityChangeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NewValue")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("NewValue");

                    b.Property<string>("OriginalValue")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("OriginalValue");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("PropertyName");

                    b.Property<string>("PropertyTypeFullName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("PropertyTypeFullName");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("EntityChangeId");

                    b.ToTable("AbpEntityPropertyChanges", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionDefinitionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<byte>("MultiTenancySide")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ParentName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Providers")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("StateCheckers")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("GroupName");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AbpPermissions", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionGrant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Name", "ProviderName", "ProviderKey")
                        .IsUnique()
                        .HasFilter("[TenantId] IS NOT NULL");

                    b.ToTable("AbpPermissionGrants", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionGroupDefinitionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AbpPermissionGroups", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.SettingManagement.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ProviderName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "ProviderName", "ProviderKey")
                        .IsUnique()
                        .HasFilter("[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");

                    b.ToTable("AbpSettings", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.SettingManagement.SettingDefinitionRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DefaultValue")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsEncrypted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInherited")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisibleToClients")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Providers")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AbpSettingDefinitions", (string)null);
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLogAction", b =>
                {
                    b.HasOne("Volo.Abp.AuditLogging.AuditLog", null)
                        .WithMany("Actions")
                        .HasForeignKey("AuditLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b =>
                {
                    b.HasOne("Volo.Abp.AuditLogging.AuditLog", null)
                        .WithMany("EntityChanges")
                        .HasForeignKey("AuditLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityPropertyChange", b =>
                {
                    b.HasOne("Volo.Abp.AuditLogging.EntityChange", null)
                        .WithMany("PropertyChanges")
                        .HasForeignKey("EntityChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLog", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("EntityChanges");
                });

            modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b =>
                {
                    b.Navigation("PropertyChanges");
                });
#pragma warning restore 612, 618
        }
    }
}
